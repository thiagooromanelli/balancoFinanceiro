import { Component, OnInit } from '@angular/core';
import { BalancoDiarioService } from 'src/app/shared/balanco-diario.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-balanco-diario',
  templateUrl: './balanco-diario.component.html',
  styles: [
  ],
})
export class BalancoDiarioComponent implements OnInit {

  constructor(public service: BalancoDiarioService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }
      
		this.service.formDataBalanco = {
      date: null,
      totValCredit: null,
      totValDebit: null,
      balance: null
		};
	}

  onSubmit(form: NgForm) {
    console.log(form)
    this.service.getBalancoDiario()
	}

}
