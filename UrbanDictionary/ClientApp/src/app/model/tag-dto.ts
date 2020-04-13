import { WordDTO } from './word-dto';

export class TagDTO {
    id : number;
    name : string;
    words: WordDTO[];
}

