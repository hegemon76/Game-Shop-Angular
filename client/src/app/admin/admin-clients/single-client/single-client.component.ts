import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EventTarget } from 'ngx-bootstrap/utils/facade/browser';
import { IClient } from 'src/app/shared/models/client';

@Component({
  selector: 'app-single-client',
  templateUrl: './single-client.component.html',
  styleUrls: ['./single-client.component.scss']
})
export class SingleClientComponent implements OnInit {
  @Input() client: IClient;
  @Output() updateClientEvent = new EventEmitter<any>();

  showClientsInfo: number;


  clientForm = new FormGroup({
    id: new FormControl(0),
    userName: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    passwordHash: new FormControl(''),
    email: new FormControl(''),
    dateOfBirth: new FormControl(''),
    roleName: new FormControl(''),
    addressBuildingNumber: new FormControl(0),
    addressCountry: new FormControl(''),
    addressStreet: new FormControl(''),
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
    addressCity?: string,
    addressBuildingNumber?: number,
    addressStreet?: number,
    passwordHash?: string,
    dateOfBirth?: Date,
    email?: string,) {
    const body = {
      'Id': id,
      'UserName': userName,
      'RoleName': roleName,
      'FirstName': firstName,
      'lastName': lastName,
      'addressCountry': addressCountry,
      'AddressZipCode': addressZipCode,
      'AddressCity': addressCity,
      'AddressStreet': addressStreet,
      'AddressBuildingNumber': addressBuildingNumber,
      'PasswordHash': passwordHash,
      'DateOfBirth': dateOfBirth,
      'Email': email,
    };

    this.updateClientEvent.emit({body, id});
  }

  setDefaults() {
    this.clientForm.controls.id.setValue(this.client.id);
    this.clientForm.controls.userName.setValue(this.client.userName);
    this.clientForm.controls.lastName.setValue(this.client.lastName);
    this.clientForm.controls.roleName.setValue(this.client.role.name);
    this.clientForm.controls.firstName.setValue(this.client.firstName);
    this.clientForm.controls.addressCountry.setValue(this.client.address.country);
    this.clientForm.controls.addressZipCode.setValue(this.client.address.zipCode);
    this.clientForm.controls.addressCity.setValue(this.client.address.city);
    this.clientForm.controls.addressBuildingNumber.setValue(this.client.address.buildingNumber);
    this.clientForm.controls.addressStreet.setValue(this.client.address.street);
    this.clientForm.controls.passwordHash.setValue(this.client.passwordHash);
    this.clientForm.controls.dateOfBirth.setValue(this.client.dateOfBirth);
    this.clientForm.controls.email.setValue(this.client.email);
  }

  showClient(id: number) {
    this.showClientsInfo = id;
  }

  closeClientInfo() {
    this.showClientsInfo = null;
  }




}