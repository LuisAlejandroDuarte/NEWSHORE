import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormValidatorService {

  constructor() { }

  campoRequerido(formGroup:FormGroup,field:string,formSend:boolean):boolean
  {
    if (formGroup.get(field).invalid && formSend)
    {return true }
    else { return false}
  }
}
