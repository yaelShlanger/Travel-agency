import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/services/home.service';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  current?:string="";
  constructor(public sh:HomeService,public sl?:LoginService){}

  ngOnInit(): void {
  }
  connect(){
    if(this.current=="אנונימי" || this.current=="מנהל")
    return false;
  return true;
  }
  manager(){
    if(this.current=="מנהל")
  return true;
  return false;
  }
}
