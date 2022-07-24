import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Pessoa } from '../model/pessoa';
import { PessoaService } from '../services/pessoa.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalAcaoPessoaComponent } from './modal-acao-pessoa/modal-acao-pessoa.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
// Icons https://fonts.google.com/icons?selected=Material+Icons
export class PessoaComponent implements OnInit {
  displayedColumns = ['id', 'nome', 'dataNascimento', 'status', 'acoes'];
  dataSource: MatTableDataSource<Pessoa>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  tabelaPessoa: Pessoa[] = []
  loading: boolean = true;
  constructor(
    private pessoaService: PessoaService,
    public dialog: MatDialog,
    private toastService: ToastrService) {
  }

  ngOnInit() {
    this.preencherTabela();
  }
  preencherTabela() {
    this.tabelaPessoa = []
    this.pessoaService.getAll()
      .subscribe((pessoas: Pessoa[]) => {
        this.tabelaPessoa = pessoas
        this.dataSource = new MatTableDataSource(this.tabelaPessoa);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, _ => {
        this.toastService.info("Não há dados para obter...");
      })
      .add(() => {
        this.loading = false
      })
  }
  filtrar(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }
  abrirModal(acaoModal: string, pessoa: Pessoa = null) {
    const dialogRef = this.dialog.open(ModalAcaoPessoaComponent, {
      width: '400px',
      data: { acaoModal, pessoa },
      position: {
        top: '20px'
      }
    });

    dialogRef.afterClosed()
      .subscribe(_ => {
        this.loading = true
        this.preencherTabela()
      });
  }

  habilitar(pessoa: Pessoa) {
    this.loading = true
    this.pessoaService.statusEnable(pessoa)
      .subscribe(() => {
        this.preencherTabela()
      }, _ => {
        this.toastService.error("Não foi possível habilitar esta pessoa...");
      })
      .add(() => {
        this.loading = false
      })
  }

  desabilitar(pessoa: Pessoa) {
    this.loading = true
    this.pessoaService.statusDisable(pessoa)
      .subscribe(() => {
        this.preencherTabela()
      }, _ => {
        this.toastService.error("Não foi possível desabilitar esta pessoa...");
      })
      .add(() => {
        this.loading = false
      })
  }
}
