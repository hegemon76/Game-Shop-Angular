import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IAddresses } from 'src/app/shared/models/address';

import { IClient } from 'src/app/shared/models/client';
import { IGenre } from 'src/app/shared/models/genres';

@Component({
  selector: 'app-single-client',
  templateUrl: './single-client.component.html',
  styleUrls: ['./single-client.component.scss']
})
export class SingleClientComponent implements OnInit {
  @Input() client: IClient;
  @Input() genres: IGenre[];
  @Input() address:IAddresses;
  @Output() updateUserEvent = new EventEmitter<any>();
  
  showClientsInfo: number;


  clientForm = new FormGroup({
    userName: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    passwordHash: new FormControl(''),
    email: new FormControl(''),
    dateOfBirth: new FormControl(''),
    roleName: new FormControl(1),
    addressBuildingNumber: new FormControl(0),
    addressStreet: new FormControl(''),
    addressCountry: new FormControl(''),
    addressZipCode: new FormControl(''),
    addressCity: new FormControl(''),
  });
  constructor() { }

  ngOnInit(): void {
    this.setDefaults();
  }
  onSubmit(
    id: number, 
    userName?: string,
    roleName?: string, 
    firstName?: string, 
    lastName?: string, 
    addressCountry?: string,
    addressZipCode?: string, 
    addressStreet?: string, 
    addressCity?: string, 
    addressBuildingNumber?: number, 
    passwordHash?: string, 
    dateOfBirth?: Date, 
    email?: string, 
) {
    const body = {
      'UserName': userName,
      'Role': {Name: roleName},
      'FirstName': firstName,
      'LastName': lastName,
      'Address': {   Country: addressCountry, 
                     ZipCode: addressZipCode,
                     City: addressCity,
                     Street: addressStreet,
                     BuildingNumber: addressBuildingNumber
                  },
      'PasswordHash': passwordHash,
      'DateOfBirth': dateOfBirth,
      'Email': email,
    };
    
    
    this.updateUserEvent.emit({ body, id });
  }

  setDefaults() {
    this.clientForm.controls.userName.setValue(this.client.userName);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
    this.clientForm.controls.firstName.setValue(this.client.firstName);
    this.clientForm.controls.lastName.setValue(this.client.lastName);
    this.clientForm.controls.passwordHash.setValue(this.client.passwordHash);
    this.clientForm.controls.dateOfBirth.setValue(this.client.dateOfBirth);
    this.clientForm.controls.email.setValue(this.client.email);
    this.clientForm.controls.addressCountry.setValue(this.client.address.country);
    this.clientForm.controls.addressZipCode.setValue(this.client.address.zipCode);
    this.clientForm.controls.addressStreet.setValue(this.client.address.street);
    this.clientForm.controls.addressCity.setValue(this.client.address.city);
    this.clientForm.controls.addressBuildingNumber.setValue(this.client.address.buildingNumber);
  }

showClient(id: number) {
  this.showClientsInfo = id;
}

closeClientInfo() {
  this.showClientsInfo = null;
}




}