import { InjectionToken } from '@angular/core';
import { UiConfiguration } from '../models/ui-configuration';

export const UiConfigurationService = new InjectionToken<UiConfiguration>('UI Configuration');
