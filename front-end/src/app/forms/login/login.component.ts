import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import { UsuarioService } from 'src/app/service/usuario.service';
import { FormValidatorService } from 'src/app/help/form-validator.service';
import { LoginForm } from 'src/app/interfaces/login.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginform:FormGroup;
  loginRequest:LoginForm;
  enviado:boolean=false;
  
  isValidFormSubmitted = false;
  constructor(private fb:FormBuilder,private validar:FormValidatorService,private router:Router,
    private usuarioService:UsuarioService,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {
    //Verifica que exista en el localstorage el usuario l.ogueado
    if (localStorage.getItem("login")) {
      this.router.navigateByUrl('/viajes');
    }

    //FormGroup para el manejo de email y password
    this.loginform = this.fb.group({
      userName:['',[Validators.required]],
      password:['',[Validators.required]]
    });
  }
  // Valida que la clave y el email sean correctos si es asi visualiza el liostado de productos
  login() {
    this.isValidFormSubmitted = false;
    this.enviado=true;
    this.loginRequest = {
      userName:this.loginform.get("userName").value,
      password:this.loginform.get("password").value
    }
    this.spinner.show(undefined, { fullScreen: true });

    this.usuarioService.login(this.loginRequest).subscribe({
      next:(resp:LoginForm)=>{
        this.spinner.hide();
        localStorage.setItem("login",JSON.stringify(resp));
        this.router.navigateByUrl('/viajes');
      },
      error:(error:any)=>{
        this.spinner.hide();
        Swal.fire("Error",error.message,'error');
      }
    })

    

   
  }
  // Valida si los campos son correctos
  vaidarCampo(filed:string) {
    this.validar.campoRequerido(this.loginform,filed,this.enviado)
}

}
