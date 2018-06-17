import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpResponse  } from "@angular/common/http";
import { Observable } from "rxjs";


@Injectable()
export class HttpService {

    private readonly proxyUrl: string = '/proxy/api';

    constructor(public httpClient: HttpClient) { }
   

    public get(url: string, params?: HttpParams): Observable<any> {
        return this.httpClient.get(this.proxyUrl, { params: this.buildQueryParams(url, params) });
    }

    public post(url: string, body: any): Observable<any> {
        return this.httpClient.post(this.proxyUrl, body, { params: this.buildQueryParams(url) });
    }

    public put(url: string, body: any): Observable<any> {
        return this.httpClient.put(this.proxyUrl, body, { params: this.buildQueryParams(url) });
    }

    public delete(url: string): Observable<any> {
        return this.httpClient.delete(this.proxyUrl, { params: this.buildQueryParams(url) });
    }

    public getHttpResponse(url: string, params?: HttpParams): Observable<HttpResponse<any>> {
        return this.httpClient.get<any>(this.proxyUrl, { observe: 'response', params: this.buildQueryParams(url, params) });
    }

    private buildQueryParams(url: string, extraParams?: HttpParams): HttpParams {
       
        let queryParams: HttpParams = new HttpParams()
        
        if(extraParams) 
            queryParams = extraParams;
      
        queryParams.set('routeUrl', url);

        return queryParams;
    }
}