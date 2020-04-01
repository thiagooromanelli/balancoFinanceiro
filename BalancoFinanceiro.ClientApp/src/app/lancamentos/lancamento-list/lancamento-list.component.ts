import { Component, OnInit } from '@angular/core';
import { LancamentoService } from 'src/app/shared/lancamento.service';
import { Lancamento } from 'src/app/shared/lancamento.model';

@Component({
	selector: 'app-lancamento-list',
	templateUrl: './lancamento-list.component.html',
	styles: []
})
export class LancamentoListComponent implements OnInit {
	constructor(public service: LancamentoService) {}

	ngOnInit(): void {
		this.service.refreshList();
	}

	populateForm(pd: Lancamento) {
		if (pd.status != 0) { // se nao estiver conciliado
			this.service.formData = Object.assign({}, pd);
		} else {
			alert('Lançamento já conciliado! Edição não permitida.');
		}
	}

	onDelete(pd) {
		if (pd.status == 0) {
			alert('Lançamento já conciliado! Deleção não permitida.');
		} else {
			if (confirm('Você tem certeza que deseja deletar este lançamento?')) {
				this.service.deletePaymentDetail(pd.id).subscribe(
					(res) => {
						this.service.refreshList();
					},
					(err) => {
						console.log(err);
					}
				);
			}
		}
	}
}
