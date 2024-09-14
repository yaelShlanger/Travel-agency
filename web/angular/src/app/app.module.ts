import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './comp/login/login/login.component';
import { RegisterComponent } from './comp/register/register/register.component';
import { HomepageComponent } from './comp/home-page/homepage/homepage.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AllTripsComponent } from './comp/all-trips/all-trips.component';
import { detailsComponent } from './comp/details/details.component';
import { privateComponent } from './comp/privateArea/private.component';
import { editComponent } from './comp/edit/edit.component';
import { MatButtonModule } from '@angular/material';
import { MatIconModule} from '@angular/material/icon';
import { MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { FooterComponent } from './comp/footer/footer.component';
import { NavComponent } from './comp/nav/nav.component';
import { ManagerComponent } from './comp/manager/manager.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomepageComponent,
    AllTripsComponent,
    detailsComponent,
    privateComponent,
    editComponent,
    privateComponent,
    FooterComponent,
    NavComponent,
    ManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,  
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
