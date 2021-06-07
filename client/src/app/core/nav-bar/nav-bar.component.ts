import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  isLogged:boolean=false;

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
  }

 logout():void{
   this.accountService.logout();
 }
}
