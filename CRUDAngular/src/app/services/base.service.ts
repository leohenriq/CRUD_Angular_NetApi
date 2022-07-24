import { HttpClient } from "@angular/common/http";
import { Base } from "../model/base";

export abstract class GenericService<T extends Base> {
  constructor(
    protected httpClient: HttpClient,
    protected urlApi: string
  ) {
  }

  getAll() {
    return this.httpClient
      .get<T[]>(`${this.urlApi}`);
  }
  getById(id: number ) {
    return this.httpClient
      .get<T>(`${this.urlApi}/${id}`);
  }
  add(objeto: T) {
    return this.httpClient
      .post<T>(`${this.urlApi}`, objeto);
  }
  update(objeto: T) {
    return this.httpClient
      .put(`${this.urlApi}/${objeto.id}`, objeto);
  }
  statusEnable(objeto: T) {
    return this.httpClient
      .put(`${this.urlApi}/StatusEnable/${objeto.id}`, objeto);
  }
  statusDisable(objeto: T) {
    return this.httpClient
      .put(`${this.urlApi}/StatusDisable/${objeto.id}`, objeto);
  }
  delete(id: number) {
    return this.httpClient
      .delete(`${this.urlApi}/${id}`);
  }
}
