import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MakePaymentComponent } from './presentation/make-payment/make-payment.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatNativeDateModule } from '@angular/material/core';

import { AddNewCardHolderComponent } from './presentation/add-new-card-holder/add-new-card-holder.component';
import { HomepageComponent } from './presentation/homepage/homepage.component';

import { ICardHolderRepository } from "../app/core/repositories/ICardHolder.repository"
import { CardholderRepository } from "../app/data/repositories/cardholder.repository";
import { TransactionsComponent } from './presentation/transactions/transactions.component';

const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'transactions', component: TransactionsComponent },
  { path: 'addNewCard', component: AddNewCardHolderComponent },
  { path: 'makePayment', component: MakePaymentComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  declarations: [
    AppComponent,
    MakePaymentComponent,
    AddNewCardHolderComponent,
    HomepageComponent,
    TransactionsComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot(),
    FormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    ReactiveFormsModule,
    NgxDatatableModule
  ],
  providers: [{ provide: ICardHolderRepository, useClass: CardholderRepository }],
  bootstrap: [AppComponent]
})
export class AppModule { }
