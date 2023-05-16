import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Song } from "../models/song";
import { Album } from "../models/album";


@Injectable({
    providedIn: 'root'
  })
  export class GameService {
  
    constructor(private httpClient : HttpClient) { }
  
    getSongsFromAlbum(id : number) : Observable<Song[]>{
      return this.httpClient.get<Song[]>(`${environment.baseApiUrl}/Albums/${id}/songs`);
    }
  
    getAlbums() : Observable<Album[]>{
      return this.httpClient.get<Album[]>(`${environment.baseApiUrl}/Albums`);
    }
  
    getSongById(id : string | null) : Observable<Song>{
      return this.httpClient.get<Song>(`${environment.baseApiUrl}/Songs/${id}`);
    }
  
  }
  