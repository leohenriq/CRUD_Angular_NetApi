import { ToastrService } from 'ngx-toastr';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pessoa } from 'src/app/model/pessoa';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-modal-acao-pessoa',
  templateUrl: './modal-acao-pessoa.component.html',
  styleUrls: ['./modal-acao-pessoa.component.css']
})
export class ModalAcaoPessoaComponent implements OnInit {
  pessoa: Pessoa = new Pessoa();
  acaoModal: string = ""
  constructor(
    private dialogRef: MatDialogRef<ModalAcaoPessoaComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private pessoaService: PessoaService,
    private toastService: ToastrService
  ) {
    this.pessoa = this.data.pessoa ?? new Pessoa()
    this.acaoModal = this.data.acaoModal
  }

  ngOnInit(): void {
  }
  realizarAcao() {
    switch (this.acaoModal) {
      case 'Adicionar':
        this.adicionar()
        break;
      case 'Editar':
        this.editar()
        break;
      case 'Deletar':
        this.deletar()
        break;
    }
  }
  adicionar() {
    this.pessoaService.add(this.pessoa)
      .subscribe(_ => {
        this.toastService.success("Adicionado com sucesso!");
        this.dialogRef.close();
      }, (err: any) => {
        this.toastService.error("Não foi possível adicionar... Tente novamente!");
        console.log(err)
      })
  }
  editar() {
    this.pessoaService.update(this.pessoa)
      .subscribe(_ => {
        this.toastService.success("Editado com sucesso!");
        this.dialogRef.close();
      }, (err: any) => {
        this.toastService.error("Não foi possível editar... Tente novamente!");
        console.log(err)
      })
  }
  deletar() {
    this.pessoaService.delete(this.pessoa.id)
      .subscribe(_ => {
        this.toastService.success("Deletado com sucesso!");
        this.dialogRef.close();
      }, (err: any) => {
        this.toastService.error("Não foi possível deletar... Tente novamente!");
        console.log(err)
      })
  }
}
