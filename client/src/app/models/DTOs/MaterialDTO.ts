export interface MaterialGetDTO{
    id: string;
    name: string;
    fat: number;
    protein: number;
    kilocalorie: number;
    kilojoule: number;
    carbohydrate: number;
    cholesterol: number;
    saturatedfat: number;
    transfat: number;
    natrium_mg: number;
    fluorite_mg: number;
    salt: number;
    sugar: number;
    scale: number;
    scaleType:string;
    updated: Date;
    updatedBy:string;
    allergen:boolean;
}