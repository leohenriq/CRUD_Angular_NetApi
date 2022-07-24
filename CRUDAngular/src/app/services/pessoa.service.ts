import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Pessoa } from "../model/pessoa";
import { GenericService } from "./base.service";

@Injectable()
export class PessoaService extends GenericService<Pessoa> {
  constructor(
    protected httpClient: HttpClient
  ) {
    super(httpClient, `${environment.urlApi}/Pessoa`);
  }
}
