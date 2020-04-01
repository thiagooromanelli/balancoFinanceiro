import { Injectable } from '@angular/core';
import { Lancamento } from './lancamento.model';
import { HttpClient } from "@angular/common/http";
import { BalancoMensal } from './balanco-mensal.model';
import { BalancoMensalResp } from './balanco-mensal-res.model';

@Injectable({
  providedIn: 'root'
})
export class BalancoMensalService {
  formDataBalancoMensal: BalancoMensal
  formDataBalancoMensalResp: BalancoMensalResp
  readonly rootURL = 'http://localhost:5000/api';
  list: BalancoMensal[]
  totBalance: number
  month: string
  
  constructor(private http: HttpClient) { }

  getBalancoMensal(){
    this.http.get(this.rootURL + '/Balanco/BalancoMensal/' + this.month)
    .toPromise()
    .then(res => {
      console.log(res)
      this.formDataBalancoMensalResp = res as BalancoMensalResp
      console.log(this.formDataBalancoMensalResp.item1)
      console.log(this.formDataBalancoMensalResp.item2)
    });
  }
}
