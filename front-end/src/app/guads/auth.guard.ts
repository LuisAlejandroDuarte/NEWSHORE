import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router:Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {

     if (!localStorage.getItem("login")) {
      console.log("GuardsEntro");
      this.router.navigateByUrl('/login');
      return false;
     }

     return true;
      console.log("Guards");

  }
}
