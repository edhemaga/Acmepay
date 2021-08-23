import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Cardholder } from 'src/app/core/domain/cardholder.model';
import { CardholderRepository } from 'src/app/data/repositories/cardholder.repository';
@Component({
  selector: 'app-add-new-card-holder',
  templateUrl: './add-new-card-holder.component.html',
  styleUrls: ['./add-new-card-holder.component.css']
})
export class AddNewCardHolderComponent implements OnInit {

  addCardHolder: FormGroup;

  constructor(public cardholderRepository: CardholderRepository) { }

  ngOnInit(): void {
    this.addCardHolder = new FormGroup({
      cardholderNumber: new FormControl(null, Validators.required),
      holderName: new FormControl(null, Validators.required),
      expirationMonth: new FormControl(null, Validators.required),
      expirationYear: new FormControl(null, Validators.required),
      CVV: new FormControl(null, Validators.required),
    });
  }

  addNewCardHolder() {
    this.cardholderRepository.addCardHolder(this.addCardHolder.value as Cardholder).subscribe(data => { console.log(data) });
  }

}
