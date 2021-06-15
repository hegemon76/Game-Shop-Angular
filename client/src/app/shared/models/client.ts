import { IAddresses } from "./address";
import { IRoles } from "./role";

export interface IClient {
    id: number;
    firstName: string;
    lastName: string;
    userName: string;
    passwordHash: string;
    email: string;
    dateOfBirth:Date;
    addressId:number;
    address: IAddresses;
    roleId:number;
    role:IRoles;
    token:string;
}