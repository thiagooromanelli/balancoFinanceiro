import { Injectable } from '@angular/core';
import { Lancamento } from './lancamento.model';
import { HttpClient } from "@angular/common/http";
import { BalancoDia } from './balanco-diario.model';

@Injectable({
  providedIn: 'root'
})
export class BalancoDiarioService {
  formDataBalanco: BalancoDia
  readonly rootURL = 'http://localhost:5000/api';
  list: BalancoDia[]
  
  constructor(private http: HttpClient) { }

  getBalancoDiario(){
    this.http.get(this.rootURL + '/Balanco/BalancoDiario/' + encodeURIComponent(this.formDataBalanco.date))
    .toPromise()
    .then(res => this.list = res as BalancoDia[]);
  }
}
