import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { LancamentoComponent } from './lancamentos/lancamento/lancamento.component';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { LancamentoService } from './shared/lancamento.service';
import { LancamentoListComponent } from './lancamentos/lancamento-list/lancamento-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LancamentoComponent,
    LancamentosComponent,
    LancamentoListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [LancamentoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
