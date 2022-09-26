import { Injectable } from '@angular/core';
import { Subject } from "rxjs";


@Injectable()
export class TimerService {

  //...other properties...

  private countdownEndSource = new Subject<void>();
  public countdownEnd$ = this.countdownEndSource.asObservable();


  mostrarTitulo() {
    this.countdownEndSource.next();
  }

  //...methods...
}
