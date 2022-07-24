import { NgModule } from '@angular/core';
import { PessoaComponent } from './pessoa.component';
import { ModalAcaoPessoaComponent } from './modal-acao-pessoa/modal-acao-pessoa.component';
import { PessoaService } from '../services/pessoa.service';
import { MaterialModule } from '../material-configuration/material.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@NgModule({
  declarations: [
    PessoaComponent,
    ModalAcaoPessoaComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
  ],
  exports:[
    PessoaComponent,
    ModalAcaoPessoaComponent
  ],
  providers: [PessoaService]
})
export class PessoaModule { }
