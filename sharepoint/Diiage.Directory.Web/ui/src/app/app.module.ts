import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { NzButtonModule } from 'ng-zorro-antd/button';

// Services
import { ConfigurationService } from './services/configuration.service';
import { UiConfigurationService } from './services/ui-configuration.service';

// Models
import { UiConfiguration } from './models/ui-configuration';
import { EmployeesComponent } from './pages/employees/employees.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { AboutComponent } from './pages/about/about.component';
import { ErrorHandlerService } from './services/errorhandler.service';
import { MsalInterceptor, MsalModule } from '@azure/msal-angular';

const initApp = (configService: ConfigurationService<UiConfiguration>, uiConfiguration: UiConfiguration) => {
  return () => configService
    .loadConfig('uiConfigurations/current')
    .then(remoteConf => {
      Object.assign(uiConfiguration, remoteConf);
    });
};
const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzFormModule,
    NzInputModule,
    NzTableModule,
    NzDescriptionsModule,
    NzButtonModule,
    MsalModule.forRoot({
      auth: {
        clientId: 'ee7c49a5-27f7-412b-b0b2-1d1deb197c3a',
        authority: 'https://login.microsoftonline.com/c39adf55-ad49-4cd2-92dd-ee972e26a0cb',
        redirectUri: 'http://localhost:4100/employees'
      },
      cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: isIE,
      }
    }, {
      popUp: !isIE,
      consentScopes: [
        'user.read',
        'openid',
        'profile',
      ],
      unprotectedResources: [],
      protectedResourceMap: [
        ['https://graph.microsoft.com/v1.0/me', ['user.read']],
        ['http://localhost:4100', ['api://ee7c49a5-27f7-412b-b0b2-1d1deb197c3a/access_as_user']]
      ],
      extraQueryParameters: {}
    })
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initApp,
      multi: true,
      deps: [ConfigurationService, UiConfigurationService]
    },{
      provide: UiConfigurationService,
      useValue: {}
    },
    { provide: ErrorHandler, useClass: ErrorHandlerService },  
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
