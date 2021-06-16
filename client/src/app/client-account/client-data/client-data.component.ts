import { Component, Input, OnInit } from '@angular/core';
import { IClient } from 'src/app/shared/models/client';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-client-data',
  templateUrl: './client-data.component.html',
  styleUrls: ['./client-data.component.scss']
})
export class ClientDataComponent implements OnInit {
  @Input() client: IClient;
  constructor() { }

  clientForm = new FormGroup({
    userId: new FormControl(),
    userName: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    addressId: new FormControl(0),
    addressZipCode: new FormControl(''),
    addressCountry: new FormControl(''),
    addressStreet: new FormControl(''),
    addressCity: new FormControl(''),
    addressBuildingNumber: new FormControl(0),
    dateOfBirth: new FormControl(''),
    roleId: new FormControl(0),
    roleName: new FormControl(''),
  });

  onSubmit(userId?: number, userName?: string, password?: string, email?: string,
    firstName?: string, lastName?: string, addressId?: number, addressZipCode?: string,
    addressCountry?: string, addressStreet?: number, addressCity?: string,
    addressBuildingNumber?: number, dateOfBirth?: any) {


    const body = {
      'Id': userId,
      'userName': userName,
      'password': password,
      'email': email,
      'firstName': firstName,
      'lastName': lastName,
      'addressId': addressId,
      'address': {
        'id': addressId,
        'zipCode': addressZipCode,
        'country': addressCountry,
        'street': addressStreet,
        'city': addressCity,
        'buildingNumber': addressBuildingNumber,
      },
      'dateOfBirth': dateOfBirth,
    }

    console.log(body);
  }

  setDefaults() {
    this.clientForm.controls.userId.setValue(this.client.id);
    this.clientForm.controls.userName.setValue(this.client.userName);
    //this.clientForm.controls.password.setValue(this.client.passwordHash);
    this.clientForm.controls.email.setValue(this.client.email);
    this.clientForm.controls.firstName.setValue(this.client.firstName);
    this.clientForm.controls.lastName.setValue(this.client.lastName);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
    this.clientForm.controls.addressId.setValue(this.client.address.id);
    this.clientForm.controls.addressZipCode.setValue(this.client.address.zipCode);
    this.clientForm.controls.addressCountry.setValue(this.client.address.country);
    this.clientForm.controls.addressStreet.setValue(this.client.address.street);
    this.clientForm.controls.addressCity.setValue(this.client.address.city);
    this.clientForm.controls.addressBuildingNumber.setValue(this.client.address.buildingNumber);
    this.clientForm.controls.dateOfBirth.setValue(this.client.dateOfBirth);
  }

  ngOnInit(): void {
    this.setDefaults();
  }

}