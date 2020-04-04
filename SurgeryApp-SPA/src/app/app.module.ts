import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { PatientListComponent } from './patients/patients-list/patient-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { Router, RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { PatientsCardComponent } from './patients/patients-card/patients-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { PatientDetailComponent } from './patients/patient-detail/patient-detail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PatientListComponent,
      ListsComponent,
      MessagesComponent,
      PatientsCardComponent,
      PatientDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      BrowserAnimationsModule
   ],
   providers: [
      AuthService,
      AuthGuard,
      UserService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
