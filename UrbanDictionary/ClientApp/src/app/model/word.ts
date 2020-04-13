import { Tag } from './tag';

export class Word {
    id : number;
    name : string;
    definition : string;
    author : string;
    creationDate : Date;
    example : string;
    image : string;
    wordStatus: number;
    likesCount: number;
    disLikesCount: number;
    tags : Tag[];
}
