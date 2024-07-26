import clsx from 'clsx';
import Heading from '@theme/Heading';
import styles from './styles.module.css';

type FeatureItem = {
  title: string;
  img: string;
  description: JSX.Element;
};

const FeatureList: FeatureItem[] = [
  {
    title: 'Easy to Use',
    img: require('@site/static/img/easy-to-use.png').default,
    description: (
      <>
        By importing the toolkit package you will be able to use all the utilities with minimal setup.
      </>
    ),
  },
  {
    title: 'Easy to customize',
    img: require('@site/static/img/easy-to-customize.png').default,
    description: (
      <>
        You can customize almost all packages default behaviour by using the available APIs.
      </>
    ),
  },
  {
    title: 'Open Source',
    img: require('@site/static/img/open-source.png').default,
    description: (
      <>
        The toolkit is fully open source and free to use, modify and redistribute.
      </>
    ),
  },
];

function Feature({title, img, description}: FeatureItem) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <img className={styles.featureImg} role="img" src={img} />
      </div>
      <div className="text--center padding-horiz--md">
        <Heading as="h3">{title}</Heading>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures(): JSX.Element {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
