import * as React from 'react';
import styles from './PersonaCard.module.scss';
import { IPersonaCardProps } from './IPersonaCardProps';

import { Log, Environment, EnvironmentType } from '@microsoft/sp-core-library';
import { SPComponentLoader } from '@microsoft/sp-loader';
import { useId, useBoolean } from '@uifabric/react-hooks';
import {
  Persona,
  PersonaSize,
  DocumentCard,
  DocumentCardType,
  Icon,
  Modal,
} from 'office-ui-fabric-react';
import { ModalBasicExample } from './modal';

const EXP_SOURCE: string = 'SPFxDirectory';
const LIVE_PERSONA_COMPONENT_ID: string =
  '914330ee-2df2-4f6e-a858-30c23a812408';

export const PersonaCard: React.FunctionComponent<IPersonaCardProps> = ({
  context,
  profileProperties,
}) => {
  const [isModalOpen, { setTrue: showModal, setFalse: hideModal }] = useBoolean(
    false
  );

  const closeModal = () => {
    hideModal();
  };
  return (
    <div className={styles.personaContainer}>
      <ModalBasicExample
        isOpen={isModalOpen}
        hideModal={closeModal}
        profile={profileProperties}
      ></ModalBasicExample>
      <DocumentCard
        className={styles.documentCard}
        type={DocumentCardType.normal}
        onClick={showModal}
      >
        <div className={styles.persona}>
          <Persona
            text={profileProperties.DisplayName}
            secondaryText={profileProperties.Title}
            tertiaryText={profileProperties.Department}
            imageUrl={profileProperties.PictureUrl}
            size={PersonaSize.size72}
            imageShouldFadeIn={false}
            imageShouldStartVisible={true}
          >
            {profileProperties.WorkPhone ? (
              <div>
                <Icon iconName="Phone" style={{ fontSize: '12px' }} />
                <span style={{ marginLeft: 5, fontSize: '12px' }}>
                  {' '}
                  {profileProperties.WorkPhone}
                </span>
              </div>
            ) : (
              ''
            )}
            {profileProperties.Location ? (
              <div className={styles.textOverflow}>
                <Icon iconName="Poi" style={{ fontSize: '12px' }} />
                <span style={{ marginLeft: 5, fontSize: '12px' }}>
                  {' '}
                  {profileProperties.Location}
                </span>
              </div>
            ) : (
              ''
            )}
          </Persona>
        </div>
      </DocumentCard>
    </div>
  );
};
