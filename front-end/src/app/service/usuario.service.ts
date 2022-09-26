import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {  tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { LoginForm } from '../interfaces/login.interface';
import { Usuario } from '../model/usuario.model';


const base_url = environment.base_url;
const headers = new HttpHeaders();
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  public usuario?:Usuario;

  constructor(private http:HttpClient,private router:Router) { }

  //Valida email password
  login(formData:LoginForm)
  {

    return this.http.post(`${base_url}/login`,formData)
                .pipe(
                  tap((resp:any)=>{
                    console.log(resp);
                  })
                )
  }


}
