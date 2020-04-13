import { TagDTO } from './tag-dto';

export class WordDTO {
    id: number;
    name: string;
    definition: string;
    author: string;
    creationDate: Date;
    example: string;
    image: string;
    wordStatus: number;
    likesCount: number;
    disLikesCount: number;
    tags: string[];
}
