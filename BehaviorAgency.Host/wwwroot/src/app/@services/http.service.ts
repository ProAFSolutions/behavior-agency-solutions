import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpResponse  } from "@angular/common/http";
import { Observable } from "rxjs";


@Injectable()
export class HttpService {

    private readonly proxyRouteUrl: string = '/proxy/api';

    constructor(public httpClient: HttpClient) { }
   

    public get(apiRouteUrl: string, params?: HttpParams): Observable<any> {
        return this.httpClient.get(this.proxyRouteUrl, { params: this.buildQueryParams(apiRouteUrl, params) });
    }

    public post(apiRouteUrl: string, body: any): Observable<any> {
        return this.httpClient.post(this.proxyRouteUrl, body, { params: this.buildQueryParams(apiRouteUrl) });
    }

    public put(apiRouteUrl: string, body: any): Observable<any> {
        return this.httpClient.put(this.proxyRouteUrl, body, { params: this.buildQueryParams(apiRouteUrl) });
    }

    public delete(apiRouteUrl: string): Observable<any> {
        return this.httpClient.delete(this.proxyRouteUrl, { params: this.buildQueryParams(apiRouteUrl) });
    }

    public getHttpResponse(apiRouteUrl: string, params?: HttpParams): Observable<HttpResponse<any>> {
        return this.httpClient.get<any>(this.proxyRouteUrl, { observe: 'response', params: this.buildQueryParams(apiRouteUrl, params) });
    }

    private buildQueryParams(apiRouteUrl: string, extraParams?: HttpParams): HttpParams {
       
        let queryParams: HttpParams = new HttpParams()
        
        if(extraParams) 
            queryParams = extraParams;
      
        queryParams.set('apiRouteUrl', apiRouteUrl);

        return queryParams;
    }
}