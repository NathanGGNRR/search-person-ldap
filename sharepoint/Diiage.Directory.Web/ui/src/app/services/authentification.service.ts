import { ApiService } from './api.service';
import { BroadcastService, MsalService } from '@azure/msal-angular';
import { Injectable } from '@angular/core';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {
  appInsights: ApplicationInsights;
    
  constructor(private broadcastService: BroadcastService, private authService: MsalService, private apiService: ApiService) {
    this.appInsights = new ApplicationInsights({
      config: {
        instrumentationKey: environment.appInsights.instrumentationKey,
        enableAutoRouteTracking: true // option to log all route changes
      }
    });
    this.appInsights.loadAppInsights();
  }

  public graphMeEndpoint = "https://graph.microsoft.com/v1.0/me";
  public isAuthenticated: boolean = false;

  login(): Promise<any> {
    return this.authService.loginPopup({
      extraScopesToConsent: ["user.read", "openid", "profile"]
    }).then(result => {
      if (result) {
        this.isAuthenticated = true
      }
    })
  }

  getProfile() {
    return this.apiService.get2(this.graphMeEndpoint, this.isAuthenticated).toPromise()
  }

  getToken() {
    const requestObj = {
      scopes: ["user.read"]
    };

    this.authService.acquireTokenSilent(requestObj).then(function (tokenResponse) {
        // Callback code here
        console.log(tokenResponse.accessToken);
    }).catch(error => {
        console.log(error);
    });
  }

  logout() {
    this.authService.logout();
  }

  logPageView(name?: string, url?: string) { // option to call manually
    this.appInsights.trackPageView({
      name: name,
      uri: url
    });
  }

  logEvent(name: string, properties?: { [key: string]: any }) {
    this.appInsights.trackEvent({ name: name}, properties);
  }

  logMetric(name: string, average: number, properties?: { [key: string]: any }) {
    this.appInsights.trackMetric({ name: name, average: average }, properties);
  }

  logException(exception: Error, severityLevel?: number) {
    this.appInsights.trackException({ exception: exception, severityLevel: severityLevel });
  }

  logTrace(message: string, properties?: { [key: string]: any }) {
    this.appInsights.trackTrace({ message: message}, properties);
  }

}
