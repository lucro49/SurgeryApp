import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PatientListComponent } from './patients/patients-list/patient-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { PatientDetailComponent } from './patients/patient-detail/patient-detail.component';


export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'patient', component: PatientListComponent},
            { path: 'patient/:id', component: PatientDetailComponent},
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];
