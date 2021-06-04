import { IGenre } from "./genres";

export interface IProduct {
    id: number;
    name: string;
    price: number;
    quantity: number;
    description: string;
    imageURL: string;
    genre: string;
}
