import { Response } from './../../shared/interfaces/response.interface';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Client } from '../interfaces/client.interface';

const baseUrl = environment.baseUrl;
interface Filters {
  id: number;
  identicacionCode: string;
  name: string;
  lastnames: string;
  mail: string;
  idTypeIdentification: number;
  address: string;
  bornDate: string;
  phone: string;
  gender: string;
}
const emptyResponse: Response<Client> = {
  succeded: false,
  message: '',
  errors: [],
  data: {} as Client,
};

@Injectable({
  providedIn: 'root',
})
export class ClientsService {
  private http = inject(HttpClient);
  clients = signal<Response<Client>>(emptyResponse);

  //metodo que retorna lista de clientes segun filtro
  getClients(filters: Filters): Observable<Response<Client>> {
    return this.http
      .get<Response<Client>>(`${baseUrl}/api/Client`, {
        params: {
          id: filters.id,
          identicacionCode: filters.identicacionCode,
          name: filters.name,
          lastnames: filters.lastnames,
          mail: filters.mail,
          idTypeIdentification: filters.idTypeIdentification,
          address: filters.address,
          bornDate: filters.bornDate,
          phone: filters.phone,
          gender: filters.gender,
        },
      })
      .pipe(tap((resp) => console.log(resp)))
      .pipe(tap((resp) => this.clients.set(resp)));
  }


}
