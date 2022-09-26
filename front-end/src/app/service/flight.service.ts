import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Flight } from '../model/flight.model';
const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class FlightService {

  constructor(private http:HttpClient,private router:Router) { }


  getAll() {
    return this.http.get(`${base_url}/GetAllFlight/`);
   }

   get(data:Flight) {
    return this.http.post(`${base_url}/GetFlight/`,data);
   }

}
