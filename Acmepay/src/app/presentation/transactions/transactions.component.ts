import { Component, OnInit } from '@angular/core';
import { PaymentRepository } from 'src/app/data/repositories/payment.repository';
import { PaymentDTO } from 'src/app/core/domain/paymentDTO.model'
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  statusSelectForm: FormGroup;

  range: FormGroup;

  pageNumber: number;
  pageSize: number;
  pageCount: number;
  pageOffset: number;
  payments: PaymentDTO[];

  filterStatus: [string, string, string] = ["Authorized", "Captured", "Voided"];

  constructor(public paymentRepository: PaymentRepository, private toastr: ToastrService) {
    this.pageNumber = 0;
    this.pageSize = 10;
    this.pageCount = 0;
    this.pageOffset = 0;
    this.range = new FormGroup({
      start: new FormControl(),
      end: new FormControl()
    });
  }

  ngOnInit(): void {
    this.paymentRepository.getPaymentCount().subscribe(data => { this.pageCount = data as number })
    this.getPagedResponse();
    this.statusSelectForm = new FormGroup({
      status: new FormControl(null),
    });
  }

  capturePayment(id: string) {
    this.paymentRepository.capturePayment(id).subscribe(data => { this.toastr.success('You have successfully captured your transaction!', data.status + ": " + data.id); this.getPagedResponse() }, () => {
      this.toastr.error("Your transaction could not be captured!");
    })
  }

  voidPayment(id: string) {
    this.paymentRepository.voidPayment(id).subscribe(data => { this.toastr.success('You have successfully voided your transaction!', data.status + ": " + data.id); this.getPagedResponse() }, () => {
      this.toastr.error("Your transaction could not be voided!");
    })
  }

  selectStatus() {
    this.paymentRepository.filterByStatus(this.statusSelectForm.value.status as string).subscribe(data => {
      this.payments = data as PaymentDTO[];
    })
  }

  filterByDate() {
    this.paymentRepository.filterByDate(this.range.value.start, this.range.value.end).subscribe(data => {
      this.payments = data as PaymentDTO[];
    })
  }

  setPage(pageInfo) {
    this.pageNumber = pageInfo.page;
    this.getPagedResponse();
  }

  getPageSize(pageSize: number) {
    this.pageNumber = 1;
    this.pageSize = pageSize;
    this.getPagedResponse();
  }

  private getPagedResponse() {
    this.paymentRepository.getPagedResponse(this.pageNumber, this.pageSize).subscribe(data => { this.payments = data as PaymentDTO[]; });
  }

}
