import { Component, OnInit} from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  current?:string="";
  showManager:boolean=false;
  
  constructor(public sl?:LoginService){}
  ngOnInit(): void {
    
  }

  get name() {
    this.current=this.sl?.userName;
    return this.current;
  }
  
  private() {
    return this.current!="אנונימי";
  }
  manager() {
    return this.current=="מנהל";
  }


  title = 'trips🏞️';
}
