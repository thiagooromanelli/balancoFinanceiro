import { Injectable } from '@angular/core';
import { Lancamento } from './lancamento.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class LancamentoService {
  formData: Lancamento
  readonly rootURL = 'http://localhost:5000/api';
  list : Lancamento[];

  constructor(private http: HttpClient) { }


  postPaymentDetail() {
    //console.log(this.formData)
    return this.http.post(this.rootURL + '/Lancamentos', this.formData);
  }
  putPaymentDetail() {
    return this.http.put(this.rootURL + '/Lancamentos/'+ this.formData.id, this.formData);
  }
  deletePaymentDetail(id) {
    return this.http.delete(this.rootURL + '/Lancamentos/'+ id);
  }

  refreshList(){
    this.http.get(this.rootURL + '/Lancamentos')
    .toPromise()
    .then(res => this.list = res as Lancamento[]);
  }
}
