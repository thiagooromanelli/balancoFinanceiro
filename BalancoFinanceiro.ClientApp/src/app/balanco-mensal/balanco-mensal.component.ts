import { Component, OnInit } from '@angular/core';
import { BalancoMensalService } from 'src/app/shared/balanco-mensal.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-balanco-mensal',
  templateUrl: './balanco-mensal.component.html',
  styles: [
  ],
})
export class BalancoMensalComponent implements OnInit {

  constructor(public service: BalancoMensalService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }
      
		this.service.formDataBalancoMensal = {
      date: null,
      totValCredit: 0,
      totValDebit: 0,
      balance: 0
    };
    
    this.service.formDataBalancoMensalResp = {
      item1: null,
      item2: 0
		};
	}

  onSubmit(form: NgForm) {
    console.log(form)
    this.service.getBalancoMensal()
	}

}
