import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ConfigurationService<TConfig> {

    private _configuration: TConfig | null;
    private _httpClient: HttpClient;

    get configuration(): TConfig {
        if (!this._configuration) {
            throw 'The configuration is not loaded, please call loadConfig before getting the configuration';
        }

        return this._configuration;
    }

    constructor(finalHandler: HttpBackend) {
        this._httpClient = new HttpClient(finalHandler);
        this._configuration = null;
    }

    loadConfig(configEndpoint: string): Promise<TConfig> {
        return this._httpClient.get<TConfig>(environment.mainApiUrl + configEndpoint)
            .toPromise()
            .then(config => {
                this._configuration = config;
                return this._configuration;
            })
            .catch(err => {
                console.error(err);
                alert("Could not load the configuration from remote endpoint, please check the console logs.");
                return Promise.reject(err);
            });
    }
}