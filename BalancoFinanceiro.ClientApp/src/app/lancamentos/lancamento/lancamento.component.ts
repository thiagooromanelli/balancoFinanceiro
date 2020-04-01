import { Component, OnInit } from '@angular/core';
import { LancamentoService } from 'src/app/shared/lancamento.service';
import { NgForm } from '@angular/forms';

@Component({
	selector: 'app-lancamento',
	templateUrl: './lancamento.component.html',
	styles: []
})
export class LancamentoComponent implements OnInit {
	constructor(public service: LancamentoService) {}

	ngOnInit(): void {
		this.resetForm();
	}

	onSubmit(form: NgForm) {
		if (this.service.formData.id == 0) this.insertRecord(form);
		else this.updateRecord(form);
	}

	resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }
      
		this.service.formData = {
			id: 0,
			date: null,
			value: null,
			type: null,
			status: null
		};
	}

	insertRecord(form: NgForm) {
		console.log(form);

		this.service.postPaymentDetail().subscribe(
			(res) => {
        alert('Lançamento cadastrado com sucesso!');
        this.service.refreshList();
        this.resetForm(form);
			},
			(err) => {
				console.log(err);
			}
		);
	}
	updateRecord(form: NgForm) {
		console.log(form);
		this.service.putPaymentDetail().subscribe(
			(res) => {
				this.resetForm(form);
				alert('Lançamento editado com sucesso!');
				this.service.refreshList();
			},
			(err) => {
				console.log(err);
			}
		);
	}
}
