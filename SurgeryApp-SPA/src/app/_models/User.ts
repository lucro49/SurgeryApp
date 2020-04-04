import { Photo } from './Photo';

export interface User {
    id: number;
    username: string;
    password: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    introduction?: string;
    photos?: Photo[];
}
