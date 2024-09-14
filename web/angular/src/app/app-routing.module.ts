import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllTripsComponent } from './comp/all-trips/all-trips.component';
import { LoginComponent } from './comp/login/login/login.component';
import { RegisterComponent } from './comp/register/register/register.component';
import { detailsComponent } from './comp/details/details.component';
import { privateComponent } from './comp/privateArea/private.component';

import { editComponent } from './comp/edit/edit.component';
import { ManagerComponent } from './comp/manager/manager.component';
import { HomepageComponent } from './comp/home-page/homepage/homepage.component';
const routes: Routes = [
  
  {path:'homePage/allTrips',component:AllTripsComponent },
  {path:'allTrips',component:AllTripsComponent },
  {path:'details',component:detailsComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'private',component:privateComponent},
  {path:'edit',component:editComponent},
  {path:'manager',component:ManagerComponent},
  {path:'allUser',component:ManagerComponent},
  {path:'homePage',component:HomepageComponent},
  {path:'allTripsToUser/private',component:AllTripsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
