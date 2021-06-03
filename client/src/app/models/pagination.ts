import { IProduct } from "./product";

export interface IPagination {
    items: IProduct[];
    totalPages: number;
    itemsFrom: number;
    itemsTo: number;
    totalItemsCount: number;
}
