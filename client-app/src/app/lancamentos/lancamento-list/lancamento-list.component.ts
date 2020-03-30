import { Component, OnInit } from '@angular/core';
import { LancamentoService } from 'src/app/shared/lancamento.service';
import { Lancamento } from 'src/app/shared/lancamento.model';

@Component({
  selector: 'app-lancamento-list',
  templateUrl: './lancamento-list.component.html',
  styles: [
  ],
})
export class LancamentoListComponent implements OnInit {

  constructor(public service: LancamentoService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(pd: Lancamento) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deletePaymentDetail(id)
        .subscribe(res => {
          this.service.refreshList();
        },
          err => {
            console.log(err);
          })
    }
  }

}
