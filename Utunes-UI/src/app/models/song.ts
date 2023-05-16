import { Album } from "./album";

export interface Song {
    id: number;
    name: string;
    artist: string;
    album: Album;
    albumId: number;
    rating: number;
}