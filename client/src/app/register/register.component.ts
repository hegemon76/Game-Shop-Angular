import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form:FormGroup;
  registerSuccessed:boolean=false;
 
  constructor(
    private formBuilder: FormBuilder,
    private accountService:AccountService,
    private route:Router
    ) { }

  ngOnInit(): void {
    this.form=this.formBuilder.group({
        userName:['',[
          Validators.required,
          Validators.minLength(4),
        ]],
        firstName:['',[
          Validators.required,
          Validators.minLength(3),
        ]],
        lastName:['',[
          Validators.required,
          Validators.minLength(3),
        ]],
        password:['',[
          Validators.required,
          Validators.minLength(6),
        ]],
        confirmPassword:['',[
          Validators.required,
          Validators.minLength(6)
        ]],
        email:['',[
          Validators.required,
          Validators.email,
          Validators.minLength(5),
        ]],
        dateOfBirth:[Date,[
          Validators.required
        ]],
        zipCode:['',[
          Validators.required,
          Validators.minLength(3),
        ]],
        country:['',[
          Validators.required,
          Validators.minLength(3),
        ]],
        buildingNumber:['',[
          Validators.required,
        ]],
        street: ['',[
          Validators.required,
          Validators.minLength(3),
        ]],
        city: ['',[
          Validators.required,
          Validators.minLength(3),
        ]],
    });
  }

  get userName(){
    return this.form.get('userName');
  }
  get firstName(){
    return this.form.get('firstName');
  }
  get lastName(){
    return this.form.get('lastName');
  }
  get dateOfBirth(){
    return this.form.get('dateOfBirth');
  }
  get password(){
    return this.form.get('password');
  }
  get confirmPassword(){
    return this.form.get('confirmPassword');
  }
  get email(){
    return this.form.get('email');
  }
  get zipCode(){
    return this.form.get('zipCode');
  }
  get country(){
    return this.form.get('country');
  }
  get buildingNumber(){
    return this.form.get('buildingNumber');
  }
  get street(){
    return this.form.get('street');
  }
  get city(){
    return this.form.get('city');
  }




  
 register():any{
    this.accountService.register(this.form.getRawValue()).subscribe(()=>{
            this.registerSuccessed=true;
  },
  error=>{
    console.log(error);
  });
  }
    
 
 
 redirectToLogin(){
this.route.navigate(['/login']);
 }
 

}
