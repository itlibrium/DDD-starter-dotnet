bin/elasticsearch-users useradd "${ES_SUPERUSER}" -p "${ES_SUPERUSER_PASSWORD}" -r superuser
bin/elasticsearch-users useradd "${ES_KIBANA01_USER}" -p "${ES_KIBANA01_PASSWORD}" -r kibana_system
cp "${ES_CONFIG_DIR}"/users /output/
cp "${ES_CONFIG_DIR}"/users_roles /output/