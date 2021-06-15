import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  model: any = {};

  constructor(
    private formBuilder: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      userName: '',
      password: '',
    });
  }

  login() {
    this.accountService.login(this.form.getRawValue()).subscribe(response => {
      console.log(response);
      if(response){
        window.location.reload()
      }
    });
    this.router.navigate(['']);
  }

}
