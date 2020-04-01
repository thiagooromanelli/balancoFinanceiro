import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { ScrollingModule } from "@angular/cdk/scrolling";

import { AppComponent } from './app.component';
import { LancamentoComponent } from './lancamentos/lancamento/lancamento.component';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { LancamentoService } from './shared/lancamento.service';
import { LancamentoListComponent } from './lancamentos/lancamento-list/lancamento-list.component';
import { BalancoDiarioComponent } from './balanco-diario/balanco-diario.component';
import { BalancoMensalComponent } from './balanco-mensal/balanco-mensal.component';

@NgModule({
  declarations: [
    AppComponent,
    LancamentoComponent,
    LancamentosComponent,
    LancamentoListComponent,
    BalancoDiarioComponent,
    BalancoMensalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ScrollingModule
  ],
  providers: [LancamentoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
