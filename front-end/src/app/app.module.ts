import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/shared/material/material.module';
import { FormsModule,ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgxSpinnerModule } from "ngx-spinner";
import { TimerService } from 'src/resource/main.service';
import { LoginComponent } from './forms/login/login.component';
import { ViajesComponent } from './forms/viajes/viajes.component';
import { MatNativeDateModule } from '@angular/material/core';
import { AuthInterceptorService } from './guads/auth-interceptor.service';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ViajesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule
  ],
  providers: [ TimerService
    
    
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
