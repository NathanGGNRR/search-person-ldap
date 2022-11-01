import { ErrorHandler, Injectable } from '@angular/core';
import { AuthentificationService } from './authentification.service';

@Injectable({providedIn: 'root'})
export class ErrorHandlerService extends ErrorHandler {

  constructor(private authService: AuthentificationService) {
        super();
    }

    handleError(error: Error) {
        this.authService.logException(error); // Manually log exception
    }
}
